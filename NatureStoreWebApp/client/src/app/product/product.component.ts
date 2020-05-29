import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ProductService } from '../product.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Product } from 'src/product';
import { Observable } from 'rxjs';
import { DiseaseService } from '../disease.service';
import { Disease } from '../disease';
import { Ingredient } from './ingredient';
import { IngredientService } from '../ingredient.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  item: Product = new Product();
  products: Product[];
  diseases: Disease[];
  ingredients: Ingredient[];

  myForm:FormGroup;
  disabled = false;
  ShowFilter = false;
  limitSelection = false;
  dropdownList: Array<Disease>;
  selectedItems: Array<Disease>;
  dropdownSettings: any = {};

  myForm1:FormGroup;
  disabled1 = false;
  ShowFilter1 = false;
  limitSelection1 = false;
  dropdownList1: Array<Ingredient>;
  selectedItems1: Array<Ingredient>;
  dropdownSettings1: any = {};

  constructor(private fb: FormBuilder, private productService: ProductService,
    private router: Router, private diseaseService: DiseaseService, private ingredientService: IngredientService)  {
    }

  ngOnInit(): void {
    this.reloadData();
    let tmp = [];

    // disease drop down
    this.diseaseService.getAllDiseases().subscribe(data=>{
      this.diseases = data as Disease[];

      for(let i=0; i < this.diseases.length; i++) {
        tmp.push({ id_disease: this.diseases[i].id_disease, name: this.diseases[i].name});
      }

      this.dropdownList = tmp;
    });

      this.selectedItems = [];

      this.dropdownSettings = {
          singleSelection: false,
          idField: 'id_disease',
          textField: 'name',
          selectAllText: 'Select All',
          unSelectAllText: 'UnSelect All',
          itemsShowLimit: 3,
          allowSearchFilter: this.ShowFilter
      };

      this.myForm = this.fb.group({
          disease: [this.selectedItems]
      });

      let tmp1 = [];
      console.log(tmp1);
      // ingredients drop down
      this.ingredientService.getAllIngredients().subscribe(data=>{
        this.ingredients = data as Ingredient[];
  
        for(let i=0; i < this.ingredients.length; i++) {
          tmp1.push({ id_ingredient: this.ingredients[i].id_ingredient, name: this.ingredients[i].name});
        }
  
        this.dropdownList1 = tmp1;
      });

      this.selectedItems1 = [];

      // ingredients drop down 
      this.dropdownSettings1 = {
          singleSelection: false,
          idField: 'id_ingredient',
          textField: 'name',
          selectAllText: 'Select All',
          unSelectAllText: 'UnSelect All',
          itemsShowLimit: 3,
          allowSearchFilter: this.ShowFilter
      };

      this.myForm1 = this.fb.group({
          ingredient: [this.selectedItems1]
      });
  }

  addProduct()
  {
    let productDiseases:Disease[] = [];

    for (let i = 0; i < this.selectedItems.length; i++) {
       console.log(this.selectedItems[i]);
       productDiseases.push(this.selectedItems[i]);
      }

    this.item.diseases = productDiseases;

    let productIngredients:Ingredient[] = [];

    for (let i = 0; i < this.selectedItems1.length; i++) {
       productIngredients.push(this.selectedItems1[i]);
      }

    this.item.ingredients = productIngredients;

    this.productService.addProduct(this.item).subscribe(data=>{console.log(data); this.reloadData();});
  }

  onSubmit(){
    console.log(this.item);
    this.addProduct();
  }

  // disease drop down methods
  onItemSelect(item: any) {
    console.log('onItemSelect', item);
    console.log(this.selectedItems);
    this.selectedItems.push(item);
  }

  onItemDeselect(item:any){
    console.log(item);
    var index: number = -1;
    
    for (var i = 0; i < this.selectedItems.length; i++) {
      if (this.selectedItems[i].id_disease == item.id_disease && this.selectedItems[i].name == item.name) {
          index = i;
      }
  }

    if (index !== -1) {
        this.selectedItems.splice(index, 1);
    }  

    console.log(this.selectedItems);
  }

  // ingredient drop down methods
  onItemSelect1(item: any) {
    console.log('onItemSelect', item);
    console.log(this.selectedItems1);
    this.selectedItems1.push(item);
  }

  onItemDeselect1(item:any){
    console.log(item);
    var index: number = -1;
    
    for (var i = 0; i < this.selectedItems1.length; i++) {
      if (this.selectedItems1[i].id_ingredient == item.id_ingredient && this.selectedItems1[i].name == item.name) {
          index = i;
      }
  }

    if (index !== -1) {
        this.selectedItems1.splice(index, 1);
    }  

    console.log(this.selectedItems1);
  }

  reloadData() {
    this.productService.getAllProducts().subscribe(data=>{
      this.products = data as Product[]});
  }

  deleteProduct(id:number)
  {
    console.log(id);
    this.productService.deleteProduct(id)
    .subscribe(
      data => {
        this.reloadData();
      },
      error => console.log(error));
  }
}

