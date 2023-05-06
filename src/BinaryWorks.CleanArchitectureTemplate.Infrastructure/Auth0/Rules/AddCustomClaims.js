function (user, context, callback) {
    const namespace = 'https://ads-sentry.com';

    if (user.app_metadata) {
        if (user.app_metadata.accountId) {
            // Add custom claims from app_metadata to the ID token
            context.idToken[`${namespace}/accountId`] = user.app_metadata.accountId;

            // Add custom claims from app_metadata to the access token
            context.accessToken[`${namespace}/accountId`] = user.app_metadata.accountId;
        }

        if (user.app_metadata.applicationUserId) {
            // Add custom claims from app_metadata to the ID token
            context.idToken[`${namespace}/applicationUserId`] = user.app_metadata.applicationUserId;

            // Add custom claims from app_metadata to the access token
            context.accessToken[`${namespace}/applicationUserId`] = user.app_metadata.applicationUserId;
        }
    }
    return callback(null, user, context);
}