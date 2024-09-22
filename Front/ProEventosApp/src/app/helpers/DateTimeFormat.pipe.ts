import { Constante } from '../util/Constante';
import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { min } from 'rxjs';



@Pipe({
  name: 'DateFormatPipe'
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

  override transform(value: any): any {
    let month = value.substring(0,2)
    let day = value.substring(3,5)
    let year = value.substring(6,10)
    // let hour = value.substring(11,13)
    // let minutes = value.substring(14,16)
    value = day + '/' + month + '/' + year;      
    return super.transform(value, Constante.DATE_FMT);
  }

}
