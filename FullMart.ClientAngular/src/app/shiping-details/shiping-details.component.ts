import { Component, OnInit } from '@angular/core';
import { Router  } from '@angular/router';

@Component({
  selector: 'app-shiping-details',
  templateUrl: './shiping-details.component.html',
  styleUrls: ['./shiping-details.component.css']
})
export class ShipingDetailsComponent implements OnInit {
  firstName: string ="";
  lastName: string ="";
  address: string ="";
  country: string=  "";
  zipCode: string= "";
  city: string ="";
  state: string="";

  constructor( private router: Router) { }

  ngOnInit() {
    const continueButton = document.querySelector('.button');
    if (continueButton) {

    continueButton.addEventListener('click', this.saveShippingDetails.bind(this));}

    // Retrieve the saved shipping details from local storage
    const savedShippingDetails = localStorage.getItem('shippingDetails');
if (savedShippingDetails !== null) {
  const shippingDetails = JSON.parse(savedShippingDetails);
  // display the saved shipping details in the HTML template
  this.firstName = shippingDetails.firstName;
  this.lastName = shippingDetails.lastName;
  this.address = shippingDetails.address;
  this.country = shippingDetails.country;
  this.zipCode = shippingDetails.zipCode;
  this.city = shippingDetails.city;
  this.state = shippingDetails.state;
}
  }

  saveShippingDetails() {
    this.firstName = (document.getElementById('firstname') as HTMLInputElement).value;
    this.lastName = (document.getElementById('lastname') as HTMLInputElement).value;
    this.address = (document.getElementById('address') as HTMLInputElement).value;
    this.country = (document.getElementById('country') as HTMLSelectElement).value;
    this.zipCode = (document.getElementById('zipcode') as HTMLInputElement).value;
    this.city = (document.getElementById('city') as HTMLInputElement).value;
    this.state = (document.getElementById('state') as HTMLSelectElement).value;

    const shippingDetails = {
      firstName: this.firstName,
      lastName: this.lastName,
      address: this.address,
      country: this.country,
      zipCode: this.zipCode,
      city: this.city,
      state: this.state
    };

    localStorage.setItem('shippingDetails', JSON.stringify(shippingDetails));
    this.router.navigate(['/order']);

  }
}
