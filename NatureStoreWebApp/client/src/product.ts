import { Disease } from './app/disease';
import { Ingredient } from './app/product/ingredient';

export class Product{

    id_product:number;
    name:string;
    price:number;
    stock:number;
    description:string;
    administration:string;
    diseases:Array<Disease>;
    ingredients:Array<Ingredient>;
}