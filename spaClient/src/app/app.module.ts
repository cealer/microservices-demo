import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProfileComponent } from './views/profile/profile.component';
import { SharedMaterialModule } from './shared/shared-material.module';
import { NavigationComponent } from './shared/components/navigation/navigation.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { UserInfoComponent } from './shared/components/user-info/user-info.component';
import { RecordsComponent } from './shared/components/records/records.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    NavigationComponent,
    UserInfoComponent,
    RecordsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    SharedMaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
