import { Cidade } from "./cidade";

export class Pessoa{
    constructor(
        public id?: number,
        public nome?: string,
        public cpf?:string,
        public idade?:number,
        public id_cidade?: number,
        public cidade?: Cidade,
    ){}
}