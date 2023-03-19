import { ICatProduct} from "./ICatProduct";




export class ICategory{

    constructor(
       public id:number,
       public categoryName:string,
       public imageUrl:string,   
       public products? :ICatProduct[],
  
    ){}

}