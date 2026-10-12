#ifndef CPPLIBRARY_H
#define CPPLIBRARY_H

#ifdef __cplusplus
extern "C"
{
#endif

    /* Returns a static, null-terminated example-message. The caller must not free the returned pointer. */
    const char *cpplibrary_get_example_message(void);

#ifdef __cplusplus
}
#endif

#endif /* CPPLIBRARY_H */
