export interface ServiceResponse<T> {
  HasExceptionError: boolean;
  ExceptionMessage: string;
  List: T[];
  Entity: T;
  Count: number;
  IsValid: boolean;
  IsSuccessful: boolean;
}
