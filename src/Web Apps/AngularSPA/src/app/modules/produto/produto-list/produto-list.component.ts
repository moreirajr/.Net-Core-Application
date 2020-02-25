import { Component, OnInit, ViewChild } from '@angular/core';
import { ProdutoService } from 'src/app/core/produtos/services/produto-service';
import { Produto } from 'src/app/core/produtos/model/produto-model';
import {MatPaginator, MatSort, MatTableDataSource, MatTable} from '@angular/material';


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
  
  listaProdutos: Produto[];
  displayedColumns: string[] = ['Id', 'Descricao', 'Valor'];
  dataSource: MatTableDataSource<Produto> = new MatTableDataSource<Produto>();
  
  constructor(private produtoService: ProdutoService) {
  }

  ngOnInit() {
    this.produtoService.getProdutos().subscribe((data : Produto[]) => {
      this.dataSource.data = data;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }
  
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

}
