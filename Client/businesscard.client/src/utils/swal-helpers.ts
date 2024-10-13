import Swal from "sweetalert2";

export class SwalHelpers {

  public static SwalWarning(message: string, confrimText: string, cancelText: string | null = null, onConfirmed: Function | null = null, onCancelled: Function | null = null) {
    Swal.fire({

      html: message,
      icon: "warning",
      iconColor: "#ffc700",
      showCancelButton: cancelText != null,
      confirmButtonText: confrimText,
      cancelButtonText: cancelText || undefined,
      customClass: {
        confirmButton: "btn btn-sm btn-primary",
        cancelButton: 'btn btn-sm btn-active-light-dark'
      }
    }).then((result) => {
      if (result.isConfirmed) {
        if (onConfirmed)
          onConfirmed();
      }
      else {
        if (onCancelled)
          onCancelled();
      }
    })
  }

  public static SwalSuccess(message: string, confrimText: string, onConfirmed: Function | null = null, onCancelled: Function | null = null) {
    Swal.fire({
      html: message,
      icon: 'success',
      confirmButtonText: confrimText,
      customClass: {
        confirmButton: "btn btn-sm btn-primary",
        cancelButton: 'btn btn-sm btn-active-light-dark'
      }
    }).then((result) => {
      if (result.isConfirmed) {
        if (onConfirmed)
          onConfirmed();
      }
      else {
        if (onCancelled)
          onCancelled();
      }
    });
  }

  public static SwalError(message: string, confrimText: string, onConfirmed: Function | null = null, onCancelled: Function | null = null) {
    Swal.fire({
      html: message,
      icon: 'error',
      confirmButtonText: confrimText,
      customClass: {
        confirmButton: "btn btn-sm btn-primary",
        cancelButton: 'btn btn-sm btn-active-light-dark'
      }
    }).then((result) => {
      if (result.isConfirmed) {
        if (onConfirmed)
          onConfirmed();
      }
      else {
        if (onCancelled)
          onCancelled();
      }
    });
  }
}
