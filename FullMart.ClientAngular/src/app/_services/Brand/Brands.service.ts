import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { IBrandDTO } from 'src/app/_models/Ibranddto';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  private apiUrl = '/api/brands';

  constructor(private http: HttpClient) { }

  getBrands(): Observable<IBrandDTO[]> {
    return this.http.get<IBrandDTO[]>(`${environment.APIURL}/Brands`)

  }

  getBrandById(id: number): Observable<IBrandDTO> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<IBrandDTO>(url);
  }


}