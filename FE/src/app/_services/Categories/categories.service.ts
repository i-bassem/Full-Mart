import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable} from 'rxjs';
import { ICategory } from 'src/app/_models/ICategory';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  constructor(private httpClient: HttpClient) { }

//// https://localhost:44308/api/Categories
   //https://localhost:44308/api/Categories/1
    //https://localhost:44308/api/Categories/GetByName?name=shoes
      //https://localhost:44308/api/Categories/17
      //   //https://localhost:44308/api/Categories
      //[HttpPost]
        //https://localhost:44308/api/Categories?id=17
       // [HttpDelete]
 getAllCategories():Observable<ICategory[]>
 {
   return this.httpClient.get<ICategory[]>(`${environment.APIURL}/Categories`)
 }
getCategoryByID(catId:number):Observable<ICategory>
{

  return this.httpClient.get<ICategory>(`${environment.APIURL}/Categories/${catId}`)
}

addCategory(newCat : ICategory)
{

}








}
