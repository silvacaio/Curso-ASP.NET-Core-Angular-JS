import { Component, OnInit } from '@angular/core';
import { SeoService, SeoModel } from '../../services/seo.service';

@Component({
  selector: 'app-lista-eventos',
  templateUrl: './lista-eventos.component.html',
  styleUrls: ['./lista-eventos.component.css']
})
export class ListaEventosComponent implements OnInit {

  constructor(seoService: SeoService) { 
    let seoModel: SeoModel = <SeoModel>{
      title: 'Próximos eventos',
      description: 'Lista dos próximos eventos de TI do Brasil',
      robots: 'Index,Follow' ,
      keywords : 'TI,Informatica, TDC'
    };

    seoService.setSeoData(seoModel);
  }

  ngOnInit() {
  }

}
