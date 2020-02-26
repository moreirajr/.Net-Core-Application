export class PaginatorOptions{
    PageSizeOptions: number[];
    PageIndex: number;

    constructor(){
        this.PageIndex = 1;
        this.PageSizeOptions = [25, 50, 75, 100];
    }
}