import { Injectable, Optional, RendererFactory2, ViewEncapsulation, Inject, Renderer2 } from '@angular/core';
import { Title, DOCUMENT } from '@angular/platform-browser';

import { StringUtils } from '../utils/string.utils';

@Injectable()
export class SeoService {
    private titleService: Title;
    private headElement: HTMLElement;
    private metaDescription: HTMLElement;
    private metaKeywords: HTMLElement;
    private robots: HTMLElement;
    private DOM: any;

    public constructor(titleService: Title, private rendererFactory: RendererFactory2,
        @Inject(DOCUMENT) private document) {

        this.titleService = titleService;

        this.DOM = this.rendererFactory.createRenderer(this.document, {
                id: '-1',
                encapsulation: ViewEncapsulation.None,
                styles: [],
                data: {}
            });

        this.headElement = this.document.head;
        this.setTitle("");

    }

    public setSeoData(seoModel: SeoModel) {
        this.setMetaDescription(seoModel.description);
        this.setMetaKeywords(seoModel.keywords);
        this.setMetaRobots(seoModel.robots);
        this.setTitle(seoModel.title);
    }

    private setTitle(newTitle: string) {
        if (StringUtils.isNullOrEmpty(newTitle))
            newTitle = "Defina um Título";

        this.titleService.setTitle(newTitle + " - Eventos.IO");
    }

    private setMetaDescription(description: string) {
        if (StringUtils.isNullOrEmpty(description))
            description = "Aqui você encontra um evento perto de você";

        this.metaDescription = this.getOrCreateMetaElement("description");
        this.metaDescription.setAttribute('content', description);
    }

    private setMetaKeywords(keywords: string) {
        if (StringUtils.isNullOrEmpty(keywords))
            keywords = "eventos,workshops,encontros";

        this.metaKeywords = this.getOrCreateMetaElement("keywords");
        this.metaKeywords.setAttribute('content', keywords);
    }

    private setMetaRobots(robots: string) {
        if (StringUtils.isNullOrEmpty(robots))
        robots = "all";

        this.robots = this.getOrCreateMetaElement("robots");
        this.robots.setAttribute('content', robots);
    }


    private getOrCreateMetaElement(name: string): HTMLElement {
        let el: HTMLElement;
        
        el = this.document.querySelector('meta[name=' + name + ']');
        if (el === null) {
            el = this.DOM.createElement('meta');
            el.setAttribute('name', name);
            this.headElement.appendChild(el);
        }
        return el;
    }
}

export class SeoModel {
    public title: string = '';
    public description: string = '';
    public robots: string = '';
    public keywords: string = '';
}