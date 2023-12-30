import { JwtPayload, jwtDecode } from "jwt-decode";
import { getLocalAccessToken } from "./helpers";
import { UserState } from "../store/user/user.reducers";

const defaultPayload: JwtPayloadExtension = {
    aud: undefined,
    iss: undefined,
    iat: undefined,
    jti: undefined,
    exp: undefined,
    nbf: undefined,
    sub: undefined,
    email: '',
    role: '',
    name: ''
};

const getDecodedToken = (): JwtPayloadExtension => {
    return getLocalAccessToken() ? jwtDecode<JwtPayloadExtension>(getLocalAccessToken()) : defaultPayload;
}

export const getUserId = (): string => {
    return getDecodedToken().sub || '';
}

export const getExpirationTime = (): number | undefined => {
    return getDecodedToken().exp;
}

export const getUserRole = (): string => {
    return getDecodedToken().role || '';
}

export const getUserEmail = (): string => {
    return getDecodedToken().email || '';
}

export const getUsername = (): string => {
    return getDecodedToken().name || '';
}

export const getUserStateFromToken = (): UserState => {
    return {
        id: getUserId(),
        name: getUsername(),
        email: getUserEmail(),
        role: getUserRole()
    };
}

interface JwtPayloadExtension extends JwtPayload {
    email: string | undefined;
    name: string | undefined;
    role: string | undefined;
}