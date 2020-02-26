export interface PaginatedResult<T> {
    PageIndex: number,
    PageSize: number,
    TotalPages: number,
    Data: T[],
    DataLenght: number
  }