
 export interface BusinessCard {
  id?: number;
  name: string;
  email: string;
  gender?: string;
  dateOfBirth?: string;
  countryCode: string;
  phone: string;
  street: string;
  city: string;
  zipcode: string;
  photo?: string;
}

export interface BusinessCardReadModel {
  id?: number;
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
