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
  
  options = {
    timeOut: 3000,
    showProgressBar: true,
    pauseOnHover: true,
    clickToClose: true
  };
  
  displayedColumns: string[] = ['Id', 'Descricao', 'Valor'];
  dataSource: MatTableDataSource<Produto>;

  teste: Produto[] = [
    {Id: 1, Descricao: 'Produto A', Valor: 100 },
    {Id: 2, Descricao: 'Produto B', Valor: 150 },
  ];

  constructor(private produtoService: ProdutoService) {
   }

  ngOnInit() {
    this.produtoService.getProdutos()
        .subscribe(data => 
            {
              //works
              //this.dataSource = new MatTableDataSource(this.teste);
                                    
              this.dataSource = new MatTableDataSource(data);

            });
  }
  
  ngAfterViewInit() {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
  }

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

}
