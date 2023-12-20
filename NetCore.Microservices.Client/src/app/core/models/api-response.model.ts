export interface ApiResponse {
    isSuccess: boolean,
    data: any,
    messages: ApiMessage[]
}

export interface ApiMessage {
    content: string,
    messageType: number
}