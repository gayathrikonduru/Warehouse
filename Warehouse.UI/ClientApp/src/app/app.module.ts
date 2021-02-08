import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ImportDataComponent } from './import-data/import-data.component';
import { ProductComponent } from './product/product.component';
import { BlockUIModule } from 'ng-block-ui';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ImportDataComponent,
    ProductComponent
  ],
  imports: [
    BlockUIModule.forRoot(),
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'import', component: ImportDataComponent },
      { path: 'products', component: ProductComponent }, 
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
