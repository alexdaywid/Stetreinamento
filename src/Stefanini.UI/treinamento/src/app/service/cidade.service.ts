import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Cidade } from '../model/cidade';
import { map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CidadeService {

  private baseUrl: string = environment.url + 'Cidade';
  constructor(private http: HttpClient) { }

  listarTodosCidades(): Observable<Cidade[]> {
    return this.http.get<Cidade[]>(this.baseUrl)
    .pipe(map((obj) => obj),
      catchError(this.handleError),
    );
  }

  criarCidade(novoCidade: Cidade): Observable<Cidade> {
    return this.http.post<Cidade>(this.baseUrl, novoCidade)
    .pipe(map((obj) => obj),
    catchError(this.handleError),
    );
  }

  buscarCidadePorId( CidadeId: number): Observable<Cidade> {
    const url = `${this.baseUrl}/${CidadeId}`;
    return this.http.get<Cidade>(url)
    .pipe(map((obj) => obj),
    catchError(this.handleError)
    );
  }

  atualizarCidade(id: any, Cidade: Cidade): Observable<Cidade> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.put<Cidade>(url, Cidade)
    .pipe(map((obj) => obj),
    catchError(this.handleError),
    );
  }

  excluir( cidadeId: number) {
    const url = `${this.baseUrl}/${cidadeId}`;
    return this.http.delete<Cidade>(url)
    .pipe(map((obj) => obj)
    );
  }


  handleError(error: any): Observable<any> {
    return (error);
  }
}
