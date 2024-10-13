using BusinessCard.Application.DTOs.BusinessCard;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("ArrayOfCreateBusinessCardRequestDto")]
public class CreateBusinessCardRequestDtoWrapper
{
    [XmlElement("CreateBusinessCardRequestDto")]
    public List<CreateBusinessCardRequestDto> BusinessCards { get; set; }
}
