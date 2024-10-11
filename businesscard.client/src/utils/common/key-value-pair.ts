export class KeyValuePair<T,W> {
  key: T;
  value: W;

  constructor(key: T, value: W) {
    this.key = key;
    this.value = value;
  }

}
