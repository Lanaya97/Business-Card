export interface ResultError {
  error: string;
  code?: string;
}

export interface Result<T> {
  data?: T;
  succeeded: boolean;
  failed: boolean;
  message?: string;
  errors: ResultError[];
  metadata: { [key: string]: any };
  exception?: any; // Can be adjusted based on the expected type
  errorCode?: number;
}


