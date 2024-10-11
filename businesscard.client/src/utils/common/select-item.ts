import { KeyValuePair } from "./key-value-pair";

export interface SelectItem<T = any> {
  label: string;
  value: T;
  title?: string;
  disabled?: boolean;
  metadata?: KeyValuePair<string, string>[];

}
