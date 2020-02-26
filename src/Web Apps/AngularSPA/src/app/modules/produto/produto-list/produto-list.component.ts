import { Component, OnInit, ViewChild } from '@angular/core';
import { ProdutoService } from 'src/app/core/produtos/services/produto-service';
import { Produto } from 'src/app/core/produtos/model/produto-model';
import {MatPaginator, MatSort, MatTableDataSource, MatTable} from '@angular/material';
import { PaginatedResult } from 'src/app/core/pagination/paginated-result';
import { PaginatorOptions } from 'src/app/core/pagination/paginator-options';


@Component({
  selector: 'app-produto-list',
  templateUrl: './produto-list.component.html',
  styleUrls: ['./produto-list.component.css']
})
export class ProdutoListComponent implements OnInit {
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;
  
  options = {
    timeOut: 3000,
    showProgressBar: true,
    pauseOnHover: true,
    clickToClose: true
  };
  
  paginatorOptions: PaginatorOptions = new PaginatorOptions();
  listaProdutos: Produto[];
  displayedColumns: string[] = ['Id', 'Descricao', 'Valor'];
  dataSource: MatTableDataSource<Produto> = new MatTableDataSource<Produto>();
  
  constructor(private produtoService: ProdutoService) {
  }

  ngOnInit() {
    this.produtoService
      .getProdutos(this.paginatorOptions.PageIndex, this.paginatorOptions.PageSizeOptions[0], 'Descricao')
      .subscribe((data : PaginatedResult<Produto>) => {
        this.dataSource.data = data.Data;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }
  
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  onPageChange(event){
    console.log(`Current page index: ${event.pageIndex}`);
  }

}
