export interface Iorder {
    id: number;
    orderProductDTOs: OrderProductDTO[];
  }
  
  export interface OrderProductDTO {
    productId: number;
    pName: string;
    price: number;
    quantity: number;
  }