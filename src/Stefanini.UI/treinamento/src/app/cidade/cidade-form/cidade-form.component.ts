import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Cidade } from 'src/app/model/cidade';
import { CidadeService } from 'src/app/service/cidade.service';

@Component({
  selector: 'app-cidade-form',
  templateUrl: './cidade-form.component.html',
  styleUrls: ['./cidade-form.component.css']
})
export class CidadeFormComponent implements OnInit {
  titulo: string = "Nova cidade"
  cidadeForm!: FormGroup;
  cidade: Cidade = new Cidade();
  id: any;
  constructor(
    private cidadeService: CidadeService,
    private fb: FormBuilder, 
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.iniciarFormulario(this.cidade);
    this.popularFormulario();
  }

  iniciarFormulario(cidade: Cidade) {
    this.cidadeForm = this.fb.group({
      id: [cidade.id],
      nome: [cidade.nome, [Validators.required]],
      uf: [cidade.uf,  Validators.compose([ Validators.required,  Validators.minLength(2), Validators.maxLength(2)]),],
    });
  }

  get nome(){
    return this.cidadeForm.get('nome')!;
  }

  get uf(){
    return this.cidadeForm.get('uf')!;
  }
  public popularFormulario(){
    if (this.route.snapshot.url[1].path === 'editar'){
        this.id = parseInt(this.route.snapshot.paramMap.get('id')!);
        this.obterCidadePorId(this.id)
    }
  }

  private obterCidadePorId(id: any){
    this.cidadeService.buscarCidadePorId(id)
      .subscribe({
        next: (res: any) => {
          this.cidade= res;
          this.atualizarCidadeForm(this.cidade);
        },
       
      })
  }

  atualizarCidadeForm(cidade: Cidade) {
    this.cidadeForm.patchValue({
      id: cidade.id,
      nome: cidade.nome,
      uf: cidade.uf,
    });
  }

  public salvarOrAtualizar(){
    if(this.cidadeForm.invalid) 
      return;    
      
      this.cidade.nome= this.cidadeForm.get('nome')?.value;
      this.cidade.uf = this.cidadeForm.get('uf')?.value;
      
    if(this.id === undefined)
      this.salvar(this.cidade);
   else
      this.atualizar(this.id, this.cidade)  
  }

  private salvar(cidade:Cidade){
    this.cidadeService.criarCidade(cidade)
    .subscribe({
      next: (res: any) => {
          alert(res.data)
          this.router.navigateByUrl('/cidade');
      },error: error => {
        alert("Ocorreu algum prblema");
      }
    
    })
  }

  private atualizar(id: number, cidade:Cidade){
    this.cidadeService.atualizarCidade(id, cidade)
      .subscribe({
        next: (res: any) => {
          this.cidade= res.data;
          this.atualizarCidadeForm(this.cidade);
          alert(res.data);
          this.router.navigateByUrl('/cidade');
        },
       error: error => {

       }
     })
  }

  
}
