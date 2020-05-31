export class Subcommand{

    CommandId_command: number;
    ProductId_product:number;
    price: number;

    constructor(id_command: number, id_product:number, price:number) {
            this.CommandId_command = id_command;
            this.ProductId_product = id_product;
            this.price = price;
    }
}