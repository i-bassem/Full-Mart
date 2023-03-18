




export interface APIResponseViewModel {

  success:boolean,
  data:any,
  messages:string[],
  //Pagination
  pageNo?:number,
  totalPages?:number,
  itemPerPage?:number,


}
