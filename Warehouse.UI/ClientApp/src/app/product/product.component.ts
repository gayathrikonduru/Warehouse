import { Component, ElementRef, ViewChild } from '@angular/core';
import { Product } from './Product';
import { ProductService } from './product.service';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

@Component({
  selector: 'product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService]
})
export class ProductComponent {

  @BlockUI() blockUI: NgBlockUI;
  products: Product[];
  errorMessage: string = "";
  constructor(private productService: ProductService) {

  }

  ngOnInit() {
    this.blockUI.start();
    this.productService.getAllProducts().subscribe(response => {
      this.products = response;
    },
      error => {
        this.errorMessage = "Error has occurred. Please try later";
        console.log("Error", error);
      })
      .add(() => {
        this.blockUI.stop();
      });
  }

  deleteProduct(id: number) {
    this.productService.deleteProduct(id).subscribe(data => {
      alert("Deleted Successfully");
      this.blockUI.start();
      this.productService.getAllProducts().subscribe(data => {
        this.products = data;
      },
        error => {
          this.errorMessage = "Error has occurred. Please try later";
          console.log("Error", error);
        })
        .add(() => {
          this.blockUI.stop();
        });
    },
      error => {
        this.errorMessage = "Error has occurred. Please try later";
        console.log("Error", error);
      });
  }
}
