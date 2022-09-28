import { Component, OnInit } from '@angular/core';
import { Pessoa } from 'src/app/model/pessoa';
import { PessoaService } from 'src/app/service/pessoa.service';

@Component({
  selector: 'app-pessoa-list',
  templateUrl: './pessoa-list.component.html',
  styleUrls: ['./pessoa-list.component.css']
})
export class PessoaListComponent implements OnInit {
  titulo: string = "Todas pessoas"
  pessoas: Pessoa[] = [];
  constructor(public pessoaService : PessoaService) { }

  ngOnInit(): void {
    this.obterTodos();
  }

  obterTodos(){
    return this.pessoaService.listarTodosPessoas()
    .subscribe( res => {
      this.pessoas = res;
    });
  }

  excluir(pessoaId: any){
    this.pessoaService.excluir(pessoaId)
    .subscribe(res =>{
      this.obterTodos();
      alert(res.data)
    });
  }

}

