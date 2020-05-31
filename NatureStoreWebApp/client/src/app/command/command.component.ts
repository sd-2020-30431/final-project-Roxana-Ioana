import { Component, OnInit } from '@angular/core';
import { Disease } from '../model/disease';
import { Location } from '@angular/common';
import { DiseaseService } from '../shared/disease.service';
import { Product } from 'src/product';
import { ProductService } from '../shared/product.service';
import { SubcommandService } from '../shared/subcommand.service';
import { CommandService } from '../shared/command.service';
import { Subcommand } from '../model/subcommand';
import { ActivatedRoute } from '@angular/router';
import { Command } from '../model/command';

@Component({
  selector: 'app-command',
  templateUrl: './command.component.html',
  styleUrls: ['./command.component.css']
})
export class CommandComponent implements OnInit {

  diseases: Disease[];
  products: Product[];
  command: Command = new Command();
  subcommands: Subcommand[];
  
  constructor(private _location: Location, private route:ActivatedRoute, private diseaseService:DiseaseService, private productService:ProductService, private subcommandService:SubcommandService, private commandService:CommandService) {
  }

  ngOnInit(): void {
    this.diseaseService.getAllDiseases().subscribe(data=>{
      this.diseases = data as Disease[];});

    this.productService.getAllProducts().subscribe(data=>{
        this.products = data as Product[];});

    var idUser = this.route.snapshot.params['idUser'];
    this.command.ApplicationUserID = idUser;
    this.commandService.addCommand(this.command).subscribe(data=>{this.command = data as Command});
  }

  onSelectDisease(disease:Disease)
  {
    console.log(disease.name);
  }

  onSelectProduct(product:Product)
  {
    //add to cart
    console.log(product);
    this.subcommandService.addSubcommand(new Subcommand(this.command.id_command, product.id_product, product.price)).subscribe(data=>console.log(data));
  }

  onBack(){
    this._location.back();
  }

  onSendCommand()
  {
    this.subcommandService.getAllSubcommands(this.command.id_command).subscribe(data=>{this.subcommands = data as Subcommand[], console.log(this.subcommands)

    var totalPrice = 0;
    for(let i=0; i<this.subcommands.length; i++)
    { 
        totalPrice += this.subcommands[i].price;
    }

    this.command.price = totalPrice;
    this.commandService.setTotalPrice(this.command);
    console.log("command sent");
    console.log(totalPrice);

    });
  }

}
