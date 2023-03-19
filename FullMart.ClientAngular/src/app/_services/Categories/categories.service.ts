import { HttpClient ,HttpErrorResponse,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, retry, throwError} from 'rxjs';
import { ICategory } from 'src/app/_models/ICategory';
import { environment } from 'src/environments/environment.development';
import { GenericAPIHandlerService } from '../_Generic-API-Handler/generic-apihandler.service';
import { APIResponseViewModel } from 'src/app/_models/api-response-view-model';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  //HTTP options sent in post/put/delete header Request
  httpOption;

  constructor(private httpClient: HttpClient, private genaricAPIHandler:GenericAPIHandlerService) {
    this.httpOption = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        //  Authorization :'my-auth-token'
      }),
    };
  }

  //#region Function for handling errors
  //Function for handling errors
  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `,
        error.error
      );
    }
    // Return an observable with a user-facing error message.
    return throwError(
      () => new Error('Something bad happened; please try again later.')
    );
  }
  //#endregion

  //https://localhost:44308/api/Categories
  getAllCategories(): Observable<ICategory[]> {

    // return this.genaricAPIHandler.getAll('Categories')
    // .pipe(
    //        map( (APIResponsevm) => {
    //         return APIResponsevm.data
    //       })
    // )

    return this.httpClient.get<ICategory[]>(`${environment.APIURL}/Categories`);
  }
  //https://localhost:7191/api/Categories/2
  getCategoryByID(catID: number): Observable<ICategory> {

    // let x =this.httpClient.get<ICategory>(`${environment.APIURL}/Categories/${catID}`);
    // console.log(x.subscribe);
    return this.httpClient.get<ICategory>(`${environment.APIURL}/Categories/${catID}`);     
  }
  //https://localhost:44308/api/Categories/GetByName?name=shoe
  getCategoryByName(catName: string): Observable<ICategory> {
    return this.httpClient.get<ICategory>(
      `${environment.APIURL}/Categories/GetByName?name=${catName}`
    );
  }
  //ADDING NEW CATEGORY
  //https://localhost:7191/api/Categories
  addCategory(newCat: ICategory): Observable<ICategory> {
    return this.httpClient.post<ICategory>( `${environment.APIURL}/Categories`, JSON.stringify(newCat), this.httpOption)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }
  //Editing An Existed Category (id, body JSON){
  // "categoryName": "string",
  // "imageUrl": "string"
 // https://localhost:7191/api/Categories/1037
  editCategory(catID:number, editedCat:ICategory){
    //console.log('2');
    //console.log(editedCat);
    return this.httpClient.put(`${environment.APIURL}/Categories/${catID}`, JSON.stringify(editedCat), this.httpOption)
  }
  //Deleting Category by ID
  //https://localhost:7191/api/Categories?id=1028
  deleteCategory(catID:number){
    return this.httpClient.delete(`${environment.APIURL}/Categories?id=${catID}`)                      
  }




}
