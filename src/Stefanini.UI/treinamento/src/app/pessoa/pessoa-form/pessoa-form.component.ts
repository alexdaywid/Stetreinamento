import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Cidade } from 'src/app/model/cidade';
import { Pessoa } from 'src/app/model/pessoa';
import { CidadeService } from 'src/app/service/cidade.service';
import { PessoaService } from 'src/app/service/pessoa.service';

@Component({
  selector: 'app-pessoa-form',
  templateUrl: './pessoa-form.component.html',
  styleUrls: ['./pessoa-form.component.css']
})
export class PessoaFormComponent implements OnInit {
  titulo: string = "Nova pessoa";
  cidades: Cidade[] = [];
  pessoaForm!: FormGroup;
  pessoa: Pessoa = new Pessoa();
  id: any;
  constructor(
    private pessoaService: PessoaService,
    private cidadeService: CidadeService,
    private fb: FormBuilder, 
    private route: ActivatedRoute,
    private router: Router,
    ) { }

  ngOnInit(): void {
    this.iniciarFormulario(this.pessoa);
    this.popularDropDownCidade();
    this.popularFormulario();


  }


  iniciarFormulario(pessoa: Pessoa) {
    this.pessoaForm = this.fb.group({
      id: [pessoa.id],
      nome: [pessoa.nome, [Validators.required]],
      cpf: [pessoa.cpf,  Validators.compose([ Validators.required,  Validators.minLength(11), Validators.maxLength(11)]),],
      idade: [pessoa.idade, [Validators.required]],
      cidade: [pessoa.cidade, [Validators.required]]
    });
  }

  get nome(){
    return this.pessoaForm.get('nome')!;
  }

  get cpf(){
    return this.pessoaForm.get('cpf')!;
  }

  get idade(){
    return this.pessoaForm.get('idade')!;
  }

  get cidade(){
    return this.pessoaForm.get('cidade')!;
  }

  public popularDropDownCidade(){
    this.cidadeService.listarTodosCidades()
    .subscribe( res => {
      this.cidades = res;
    }, erro =>{
      alert("Problema ao carregar as cidades");
    });
  }

  public popularFormulario(){
    if (this.route.snapshot.url[1].path === 'editar'){
        this.id = parseInt(this.route.snapshot.paramMap.get('id')!);
        this.obterPessoaPorId(this.id)
    }
  }

  private obterPessoaPorId(id: any){
    this.pessoaService.buscarPessoaPorId(id)
      .subscribe({
        next: (res: any) => {
          this.pessoa= res;
          this.atualizarPessoaForm(this.pessoa);
        },
       
      })
  }

  atualizarPessoaForm(pessoa: Pessoa) {
    this.pessoaForm.patchValue({
      id: pessoa.id,
      nome: pessoa.nome,
      idade: pessoa.idade,
      cpf: pessoa.cpf,
      cidade: pessoa.cidade?.id
    });
  }

  public salvarOrAtualizar(){
    if(this.pessoaForm.invalid) 
      return;    
      
      this.pessoa.nome= this.pessoaForm.get('nome')?.value;
      this.pessoa.idade = this.pessoaForm.get('idade')?.value;
      this.pessoa.cpf = this.pessoaForm.get('cpf')?.value;
      this.pessoa.id_cidade = this.pessoaForm.get('cidade')?.value;
      
    if(this.id === undefined)
      this.salvar(this.pessoa);
   else
      this.atualizar(this.id, this.pessoa)  
  }

  private salvar(pessoa: Pessoa){
    this.pessoaService.criarPessoa(pessoa)
    .subscribe({
      next: (res: any) => {
          alert(res.data)
          this.router.navigateByUrl('/pessoa');
      },error: error => {
        alert("Ocorreu algum prblema");
      }
    
    })
  }

  private atualizar(id: number, pessoa: Pessoa){
    this.pessoa.cidade= undefined;
    this.pessoaService.atualizarPessoa(id, pessoa)
      .subscribe({
        next: (res: any) => {
          this.pessoa= res.data;
          this.atualizarPessoaForm(this.pessoa);
          alert(res.data);
          this.router.navigateByUrl('/pessoa');
        },
       error: error => {

       }
     })
  }

}
