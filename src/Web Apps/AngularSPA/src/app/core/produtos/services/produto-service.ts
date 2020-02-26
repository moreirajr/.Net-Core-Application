import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Produto } from '../model/produto-model';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../../pagination/paginated-result';

const baseUrl = 'http://localhost:54014/api/v1/produto';

@Injectable()
export class ProdutoService {

  constructor(private http: HttpClient) { }

  produto: Produto;

  save(novoProduto: Produto) {

    console.log('salvar produto: ', novoProduto);

    return this.http
        .post<Produto>(
            baseUrl,
            this.produto,
            { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
        ).subscribe(data => { });
  }

  getProdutos(pageIndex: number, pageSize: number, sort: string): Observable<PaginatedResult<Produto>> {   
    return this.http.get<PaginatedResult<Produto>>(`${baseUrl}?pageIndex=${pageIndex}&pageSize=${pageSize}&sort=${sort}`);
  }

  getProdutoPorId(id: number): Observable<Produto>{
    return this.http.get<Produto>(`${baseUrl}/${id}`);
  }

}