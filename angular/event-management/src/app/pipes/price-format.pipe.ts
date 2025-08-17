import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'priceFormat'
})
export class PriceFormatPipe implements PipeTransform {
  transform(value: number): string {
    if (!value && value !== 0) return '';
    return new Intl.NumberFormat('en-IN', { style: 'currency', currency: 'INR' }).format(value);
  }
}
