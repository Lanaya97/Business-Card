
 export interface BusinessCard {
  name: string;
  email: string;
  gender: string;
  dateOfBirth?: string;
  countryCode: string;
  number: string;
  street: string;
  city: string;
  zipcode: string;
  photo?: string;
}

export interface BusinessCardReadModel {
  id?: string;
  name: string;
  email: string;
  gender?: string;
  dateOfBirth?: string;
  phoneNumber: PhoneNumber;
  address: Address;
  photo?: string;
}

interface PhoneNumber {
  countryCode: string;
  number: string;
}
interface Address {
  street: string;
  city: string;
  zipcode: string;
}
