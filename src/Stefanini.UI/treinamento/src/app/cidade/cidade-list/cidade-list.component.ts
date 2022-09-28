import { Component, OnInit } from '@angular/core';
import { Cidade } from 'src/app/model/cidade';
import { CidadeService } from 'src/app/service/cidade.service';

@Component({
  selector: 'app-cidade-list',
  templateUrl: './cidade-list.component.html',
  styleUrls: ['./cidade-list.component.css']
})
export class CidadeListComponent implements OnInit {
  titulo: string = "Todas cidades"
  cidades: Cidade[] = [];
 
  constructor(private cidadeService: CidadeService) { }

  ngOnInit(): void {
    this.obterTodos();
  }


  obterTodos(){
    return this.cidadeService.listarTodosCidades()
    .subscribe( res => {
      this.cidades = res;
    });
  }

  excluir(cidadeId: any){
    this.cidadeService.excluir(cidadeId)
    .subscribe({
      next: (res: any) => {
        this.obterTodos();
        alert(res.data)
      }, error: erro => {
       alert(erro.error.errors[0])
      }
    });
  }

 


}
