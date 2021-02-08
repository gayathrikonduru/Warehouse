import { Component, ElementRef, ViewChild } from '@angular/core';
import { ImportDataService } from './import-data.service';
//import { FileToUpload } from './file-to-upload';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

@Component({
  selector: 'import-data',
  templateUrl: './import-data.component.html',
  styleUrls: ['./import-data.component.css'],
  providers: [ImportDataService]
})

export class ImportDataComponent {

  @BlockUI() blockUI: NgBlockUI;
  @ViewChild('inputFile') inputFile: ElementRef;
  @ViewChild('btnSubmit') btnSubmit: ElementRef;
  @ViewChild('importTypeSelect') importTypeSelect: ElementRef;
  file: any = null;
  importTypeSelected: string = "";
  fileData: any = "";
  errorMessage: any = "";
  importTypes = ImportType;
  importTypeKeys = [];

  constructor(private importDataService: ImportDataService) {
    this.importTypeKeys = Object.keys(this.importTypes);    
  }

  onSubmit(data: any) {
    this.blockUI.start();
    this.readAndUploadFile(this.file, data.importType);
  }

  onFileChange(event) {
    this.errorMessage = "";
    this.file = null;
    if (event.target.files && event.target.files.length > 0) {   
      this.file = event.target.files[0];
    }
  }

  onImportTypeChange(value) {    
    this.importTypeSelected = value;  
  }

  private readAndUploadFile(file: any, importtype: ImportType) {  
    let reader = new FileReader();

    reader.onload = () => {
      if (file.size > 0) {
        this.fileData = reader.result;                
      }
      else {
        this.fileData = "";
      }

      //POST to server
      this.importDataService.uploadFile(this.fileData, importtype).subscribe(
        resp => {
          alert("Imported successfully");
          console.log("ImportResponse", resp);          
          },
          error => {
            this.errorMessage = "Something went wrong, please try again later";
          })
          .add(() => {
            this.blockUI.stop();
            this.resetInputFields();
          });     
    }
    // Read the file
    reader.readAsText(file);
  }

  resetInputFields(): void {
    this.file = null;
    this.importTypeSelected = "";
    this.inputFile.nativeElement.value = '';    
    this.importTypeSelect.nativeElement.SelectedIndex = 0;
    this.importTypeSelect.nativeElement.value = "";

  } 
}

export enum ImportType {
  Products = "Products",
  Articles = "Inventory"
}
