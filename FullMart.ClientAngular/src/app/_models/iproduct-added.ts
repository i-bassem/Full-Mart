export class IProductAdded {
    constructor(
        public  pName:string,
        public  pDescription:string,
        public  price:number,
        public  rate:number,
        public  quantity:number,
        public  imageUrl:string ,
        public  categoryId:number,
        public  brandId:number
    ){}
}
