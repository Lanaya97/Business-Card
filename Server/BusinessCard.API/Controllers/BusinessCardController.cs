using BusinessCard.Application.Commands.BusinessCard.Create;
using BusinessCard.Application.Commands.BusinessCard.Delete;
using BusinessCard.Application.Common;
using BusinessCard.Application.DTOs.BusinessCard;
using BusinessCard.Application.Queries.BusinessCard;
using BusinessCard.Application.ReadModels.BusinessCard;
using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace BusinessCard.Server.Controllers
{
    [ApiController]
    [Route("api/card")]
    public class BusinessCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusinessCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region General
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] DataTablesParameters parameters)
        {
            var result = await _mediator.Send(new GetBusinessCardsQuery() { Options = parameters.ToQueryOptions() });

            if (result.Failed)
                return BadRequest(result);

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBusinessCardRequestDto request)
        {
            var result = await _mediator.Send(new CreateBusinessCardCommand()
            {
                Name = request.Name,
                Email = request.Email,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                CountryCode = request.CountryCode,
                Phone = request.Number,
                Street = request.Street,
                City = request.City,
                ZipCode = request.ZipCode,
                Photo = request.Photo

            });

            if (result.Failed)
                return BadRequest(result);

            return Ok(result);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var result = await _mediator.Send(new DeleteBusinessCardCommand() { Id = id });

            if (result.Failed)
                return BadRequest(result);

            return Ok(result);
        }
        #endregion

        #region Imports
        [HttpPost("import/csv")]
        public async Task<IActionResult> ImportFromCsvAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty.");
            }

            using (var streamReader = new StreamReader(file.OpenReadStream()))
            using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                var data = csvReader.GetRecords<CreateBusinessCardRequestDto>().ToList();
                if (data == null || data.Count == 0)
                {
                    return BadRequest("An error occured while trying to read the data.");
                }

                List<Guid> ids = new();
                foreach (var record in data)
                {
                    var result = await _mediator.Send(new CreateBusinessCardCommand()
                    {
                        Name = record.Name,
                        Email = record.Email,
                        Gender = record.Gender,
                        DateOfBirth = record.DateOfBirth,
                        CountryCode = record.CountryCode,
                        Phone = record.Number,
                        Street = record.Street,
                        City = record.City,
                        ZipCode = record.ZipCode,
                        Photo = record.Photo
                    });

                    ids.Add(result.Data);
                }
                return Ok(new Result<List<Guid>>() { Data = ids });
            }
        }

        [HttpPost("import/xml")]
        public async Task<IActionResult> ImportFromXmlAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty.");
            }

            var serializer = new XmlSerializer(typeof(List<CreateBusinessCardRequestDto>));

            using (var stream = file.OpenReadStream())
            {
                var data = (List<CreateBusinessCardRequestDto>)serializer.Deserialize(stream);

                if(data == null || data.Count == 0)
                {
                    return BadRequest("An error occured while trying to read the data.");
                }

                List<Guid> ids = new();
                foreach (var record in data)
                {
                  var result = await _mediator.Send(new CreateBusinessCardCommand()
                  {
                        Name = record.Name,
                        Email = record.Email,
                        Gender = record.Gender,
                        DateOfBirth = record.DateOfBirth,
                        CountryCode = record.CountryCode,
                        Phone = record.Number,
                        Street = record.Street,
                        City = record.City,
                        ZipCode = record.ZipCode,
                        Photo = record.Photo
                  });

                    ids.Add(result.Data);
                }

                return Ok(new Result<List<Guid>>() { Data = ids });
            }
        }
        #endregion

        #region Exports
        [HttpPost("export/csv")]
        public async Task<IActionResult> ExportToCsvAsync([FromBody] DataTablesParameters parameters)
        {

            var result = await _mediator.Send(new GetBusinessCardsQuery() { Options = parameters.ToQueryOptions() });

            if (result.Failed)
                return BadRequest(result);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter, csvConfig))
            {
                csvWriter.WriteRecords(result.Data);
                streamWriter.Flush();
                return File(memoryStream.ToArray(), "text/csv", "Business-Cards.csv");
            }
        }

        [HttpPost("export/xml")]
        public async Task<IActionResult> ExportToXmlAsync([FromBody] DataTablesParameters parameters)
        {
            var result = await _mediator.Send(new GetBusinessCardsQuery() { Options = parameters.ToQueryOptions() });

            if (result.Failed)
                return BadRequest(result);

            var serializer = new XmlSerializer(typeof(List<BusinessCardReadModel>));
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                serializer.Serialize(streamWriter, result.Data);
                return File(memoryStream.ToArray(), "application/xml", "Business-Cards.xml");
            }
        }

        #endregion
    }
}
