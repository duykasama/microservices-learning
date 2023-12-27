import { TokenType } from "../models/tokens.enum"

export const getLocalAccessToken = (): string => {
    return localStorage.getItem(TokenType.ACCESS_TOKEN) || '';
}