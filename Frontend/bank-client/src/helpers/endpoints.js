const dbDomain = 'http://localhost:31310'
const endpoints = {
	userAPI: `${dbDomain}/api/user`,
	bankAccountAPI: `${dbDomain}/api/bankaccount`,
	cardAPI: `${dbDomain}/api/card`,
	transferAPI: `${dbDomain}/api/transfer`
}

export const { userAPI, bankAccountAPI, cardAPI, transferAPI } = endpoints
export default endpoints 