const dbDomain = 'http://localhost:31310'
const endpoints = {
	userAPI: `${dbDomain}/api/user`,
	bankAccountAPI: `${dbDomain}/api/bankaccount`,
	cardAPI: `${dbDomain}/api/card`,
	transferAPI: `${dbDomain}/api/transfer`,
	customerAPI: `${dbDomain}/api/customer`
}

export const { userAPI, bankAccountAPI, cardAPI, transferAPI, customerAPI } = endpoints
export default endpoints 