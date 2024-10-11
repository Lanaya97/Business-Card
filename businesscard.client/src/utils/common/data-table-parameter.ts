export interface DataTablesParameters {
    draw: number
    start: number
    length: number
    order?: Order | null
    filters: Filter[]
}


export interface Filter {
    name: string
    value: any
}

export interface Order {
    name: string
    dir: any
}
