import { Pipe, PipeTransform } from '@angular/core';

 

@Pipe({

name: 'nl2br'

})

export class nl2brPipe implements PipeTransform {

 

transform(value: any): any {

return value.replace(/\n/g, '<br/>');

}

 

}