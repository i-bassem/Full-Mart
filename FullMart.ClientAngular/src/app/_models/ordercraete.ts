export interface OrderCreateDTO {
    orderProducts: OrderProductCreateDTO[];
  }
  
  export interface OrderProductCreateDTO {
    productId: number;
  }