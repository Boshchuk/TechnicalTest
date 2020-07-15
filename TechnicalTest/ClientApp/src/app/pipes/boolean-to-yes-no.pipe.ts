import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'booleanToYesNo'
})
export class BooleanToYesNoPipe implements PipeTransform {

  transform(value: boolean): any {
    // note: there is no translations here
    return value ? "Yes" : "No";
  }

}
