
export const getAccessToken = () => {
    const token = localStorage.getItem('token')
    if (token) {
        const { accessToken } = JSON.parse(token)
        return accessToken
    }
    else {
        return null
    }
}

export const getRefreshToken = () => {
    const token = localStorage.getItem('token')
    if (token) {
        const { refreshToken } = JSON.parse(token)
        return refreshToken
    }
    else {
        return null
    }
}

export const setToken = (token) => {
    if(token){
        localStorage.setItem("token", JSON.stringify(token))
    }
}
