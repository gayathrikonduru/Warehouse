
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
//import { FileToUpload } from './file-to-upload';
import { Injectable } from '@angular/core';

const API_URL = "https://localhost:44393/api/import/";
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',    
  })
};
@Injectable({  
  providedIn: 'root',
})
export class ImportDataService {
  constructor(private http: HttpClient) { }

  uploadFile(fileData: string, importType: any): Observable<any> {
    return this.http.post<string>(API_URL + importType, JSON.stringify(fileData), httpOptions);
  }
}
