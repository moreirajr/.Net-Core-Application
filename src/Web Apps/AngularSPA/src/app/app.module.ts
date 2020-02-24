import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HomeComponent } from './modules/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './modules/modules-config/material-module';
import { LayoutModule } from '@angular/cdk/layout';
import { AppRoutingModule } from './modules/modules-config/app-routing.module';
import { ProdutoService } from './core/produtos/services/produto-service';
import { ProdutoComponent } from './modules/produto/produto.component';
import { ProdutoListComponent } from './modules/produto/produto-list/produto-list.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProdutoComponent,
    ProdutoListComponent
  ],
  imports: [
    MaterialModule,
    HttpClientModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule
  ],
  providers: [ProdutoService],
  bootstrap: [AppComponent]
})
export class AppModule { }