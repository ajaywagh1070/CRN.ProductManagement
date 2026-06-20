import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Login } from './pages/login/login';
import { Products } from './pages/products/products';
import { Items } from './pages/items/items';
import { Navbar } from './shared/navbar/navbar';

@NgModule({
  declarations: [App, Login, Products, Items, Navbar],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [provideBrowserGlobalErrorListeners()],
  bootstrap: [App],
})
export class AppModule {}
