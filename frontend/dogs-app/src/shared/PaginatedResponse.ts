export interface PaginatedResponse<T> {
  pageNumber: number;
  totalPages: number;
  totalCount: number;
  pageSize: number;
  items: T[];
}