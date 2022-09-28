import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Pessoa } from '../model/pessoa';

@Injectable({
  providedIn: 'root'
})
export class PessoaService {

  private baseUrl: string = environment.url + 'pessoa';
  constructor(private http: HttpClient) { }

  listarTodosPessoas(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(this.baseUrl)
    .pipe(map((obj) => obj),
      catchError(this.handleError),
    );
  }

  criarPessoa(novoPessoa: Pessoa): Observable<Pessoa> {
    return this.http.post<Pessoa>(this.baseUrl, novoPessoa)
    .pipe(map((obj) => obj),
    catchError(this.handleError),
    );
  }

  buscarPessoaPorId( PessoaId: number): Observable<Pessoa> {
    const url = `${this.baseUrl}/${PessoaId}`;
    return this.http.get<Pessoa>(url)
    .pipe(map((obj) => obj),
    catchError(this.handleError)
    );
  }

  atualizarPessoa(id: number, Pessoa: Pessoa): Observable<Pessoa> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.put<Pessoa>(url, Pessoa)
    .pipe(map((obj) => obj),
    catchError(this.handleError),
    );
  }

  excluir( PessoaId: number) {
    const url = `${this.baseUrl}/${PessoaId}`;
    return this.http.delete<Pessoa>(url)
    .pipe(map((obj) => obj),
    catchError(this.handleError)
    );
  }


  handleError(error: any): Observable<any> {
    return (error);
  }
}
